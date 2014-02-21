using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.IO;
using SteamKit2;

namespace SyncSteam
{
    public partial class frmMain : Form
    {
        //static bool isConsole = true;
        static SteamClient steamClient;
        static CallbackManager manager;

        static SteamUser steamUser;
        static SteamFriends steamFriends;

        static bool isRunning;//, isRequireSteamGuard;

        static string user, pass;
        static string authCode = null;  // 인증코드 [2/20/2014 Mark]

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "접속 중...";
            btnSignIn.Enabled = false;

            user = txtID.Text;
            pass = txtPW.Text;

            // 스팀 클라이언트 만듦.
            steamClient = new SteamClient(System.Net.Sockets.ProtocolType.Tcp); 
            // 콜백 매니저 생성
            manager = new CallbackManager(steamClient);

            // 스팀 유저 핸들러
            steamUser = steamClient.GetHandler<SteamUser>();
            // 친구 핸들러, 로그인 후에 동작.
            steamFriends = steamClient.GetHandler<SteamFriends>();

            // register a few callbacks we're interested in
            // these are registered upon creation to a callback manager, which will then route the callbacks
            // to the functions specified
            new Callback<SteamClient.ConnectedCallback>(OnConnected, manager);
            new Callback<SteamClient.DisconnectedCallback>(OnDisconnected, manager);

            new Callback<SteamUser.LoggedOnCallback>(OnLoggedOn, manager);
            new Callback<SteamUser.LoggedOffCallback>(OnLoggedOff, manager);

            // we use the following callbacks for friends related activities
            new Callback<SteamUser.AccountInfoCallback>(OnAccountInfo, manager);
            new Callback<SteamFriends.FriendsListCallback>(OnFriendsList, manager);
            new Callback<SteamFriends.PersonaStateCallback>(OnPersonaState, manager);
            new Callback<SteamFriends.FriendAddedCallback>(OnFriendAdded, manager);
            
            // this callback is triggered when the steam servers wish for the client to store the sentry file
            new JobCallback<SteamUser.UpdateMachineAuthCallback>(OnMachineAuth, manager);

            isRunning = true;

            Console.WriteLine( "Connecting to Steam..." );
            //lstLog.Items.Add("스팀 연결 중...");

            // initiate the connection
            steamClient.Connect();

            Thread ConnThread = new Thread(new ThreadStart(ConnectionThread));
            ConnThread.Start();


        }

        public static void ConnectionThread()
        {
            // create our callback handling loop
            while (isRunning)
            {
                // in order for the callbacks to get routed, they need to be handled by the manager
                manager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
            }
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            btnAuth.Enabled = false;
            txtSteamGuardCode.Enabled = false;

            Console.WriteLine("인증코드를 스팀으로 보내는 중...");
            //lstLog.Items.Add("인증코드를 스팀으로 보내는 중...");

            user = txtID.Text;
            pass = txtPW.Text;
            authCode = txtSteamGuardCode.Text;

            isRunning = true;
            //steamClient.Connect();

            while (isRunning)
            {
                // in order for the callbacks to get routed, they need to be handled by the manager
                manager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
            }

        }



        private void txtID_TextChanged(object sender, EventArgs e)
        {
            IdentificationStringCheck();
        }

        private void txtPW_TextChanged(object sender, EventArgs e)
        {
            IdentificationStringCheck();
        }

        private void IdentificationStringCheck()
        {
            if (txtID.Text.Length == 0 || txtPW.Text.Length == 0)
                btnSignIn.Enabled = false;
            else
                btnSignIn.Enabled = true;
        }




#region STEAM_FRIENDS

        void OnAccountInfo(SteamUser.AccountInfoCallback callback)
        {
            // before being able to interact with friends, you must wait for the account info callback
            // this callback is posted shortly after a successful logon

            // at this point, we can go online on friends, so lets do that
            steamFriends.SetPersonaState(EPersonaState.Online);
        }

        void OnFriendsList(SteamFriends.FriendsListCallback callback)
        {
            // at this point, the client has received it's friends list
            int friendCount = steamFriends.GetFriendCount();

            Console.WriteLine("We have {0} friends", friendCount);
            lstLog.Items.Add(String.Format("{0} 명의 친구 목록을 불러옵니다.", friendCount));

            for (int x = 0; x < friendCount; x++)
            {
                // steamids identify objects that exist on the steam network, such as friends, as an example
                SteamID steamIdFriend = steamFriends.GetFriendByIndex(x);

                // we'll just display the STEAM_ rendered version
                Console.WriteLine("Friend: {0}", steamIdFriend.Render());
                //lstLog.Items.Add(String.Format("친구: {0}", steamIdFriend.Render()));
                lstFriendList.Items.Add(steamIdFriend.AccountID);
            }

            // we can also iterate over our friendslist to accept or decline any pending invites

            foreach (var friend in callback.FriendList)
            {
                if (friend.Relationship == EFriendRelationship.RequestRecipient)
                {
                    // this user has added us, let's add him back
                    steamFriends.AddFriend(friend.SteamID);
                }
            }

        }

        void OnFriendAdded(SteamFriends.FriendAddedCallback callback)
        {
            // someone accepted our friend request, or we accepted one
            Console.WriteLine("{0} is now a friend", callback.PersonaName);
            lstLog.Items.Add(String.Format("{0}님이 당신과 친구가 되었습니다.", callback.PersonaName));
        }

        void OnPersonaState(SteamFriends.PersonaStateCallback callback)
        {
            // this callback is received when the persona state (friend information) of a friend changes

            // for this sample we'll simply display the names of the friends
            Console.WriteLine("State change: {0}", callback.Name);
            //lstLog.Items.Add(String.Format("상태 변경: {0}", callback.Name));

            String strCurrFindID = callback.FriendID.AccountID.ToString();
            String strCurrName = callback.Name.ToString();
            int currIdx = lstFriendList.FindString(strCurrFindID);
            if (currIdx != -1)
            {
                lstFriendList.Items[currIdx] = strCurrName;
            }
            

            //isRunning = false;
        }
#endregion

#region STEAM_CONNECTION
        // 스팀 연결 부분 [2/20/2014 Mark]
        void OnConnected(SteamClient.ConnectedCallback callback)
        {
            if (callback.Result != EResult.OK)
            {
                Console.WriteLine( "Unable to connect to Steam: {0}", callback.Result );
                lstLog.Items.Add(String.Format("연결 실패 : {0}", callback.Result));

                isRunning = false;
                return;
            }

            Console.WriteLine("Connected to Steam! Logging in '{0}'...", user);
            lstLog.Items.Add(String.Format("해당 계정으로 로그인 중 '{0}'...", user));

            byte[] sentryHash = null;
            if (File.Exists("sentry.bin"))
            {
                // 파일이 있으면 sha-1로 읽는다.
                byte[] sentryFile = File.ReadAllBytes("sentry.bin");
                sentryHash = CryptoHelper.SHAHash(sentryFile);
            }

            steamUser.LogOn(new SteamUser.LogOnDetails
            {
                Username = user,
                Password = pass,

                // in this sample, we pass in an additional authcode
                // this value will be null (which is the default) for our first logon attempt
                AuthCode = authCode,

                // our subsequent logons use the hash of the sentry file as proof of ownership of the file
                // this will also be null for our first (no authcode) and second (authcode only) logon attempts
                SentryFileHash = sentryHash,
            });
        }

        void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            // after recieving an AccountLogonDenied, we'll be disconnected from steam
            // so after we read an authcode from the user, we need to reconnect to begin the logon flow again

            Console.WriteLine("접속이 끊어짐, 5초 후 재접속 합니다...");
            lstLog.Items.Add("접속이 끊어짐, 5초 후 재접속 합니다...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            steamClient.Connect();
        }

        // sign-in [2/20/2014 Mark]
        void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            if (callback.Result == EResult.AccountLogonDenied)
            {

                Console.WriteLine("이 계정은 인증코드를 필요로 합니다.");
                Console.WriteLine(String.Format("고객님의 {0}으로 메일을 보냈으니, 확인하시고 입력 해주세요. ", callback.EmailDomain));
                lstLog.Items.Add("이 계정은 인증코드를 필요로 합니다.");
                lstLog.Items.Add(String.Format("고객님의 {0}으로 메일을 보냈으니, 확인하시고 입력 해주세요. ", callback.EmailDomain));


                //authCode = Console.ReadLine();
                txtID.ReadOnly = true;
                txtPW.ReadOnly = true;
                txtSteamGuardCode.Enabled = true;
                btnAuth.Enabled = true;

                if (authCode == null)
                {   // 인증 코드가 없으면 서버연결 중지하고 인증 코드 받는다. [2/20/2014 Mark]
                    isRunning = false;
                    return;
                }
            }

            if (callback.Result != EResult.OK)
            {
                Console.WriteLine("Unable to logon to Steam: {0} / {1}", callback.Result, callback.ExtendedResult);
                lstLog.Items.Add(String.Format("로그인 할 수 없음. {0} / {1}", callback.Result, callback.ExtendedResult));

                isRunning = false;
                return;
            }

            txtID.ReadOnly = true;
            txtPW.ReadOnly = true;

            // 스팀 로그인 성공 [2/20/2014 Mark]
            Console.WriteLine("Successfully logged on!");
            lstLog.Items.Add("로그인 성공!");
            lblStatus.Text = "연결됨.";
            


                        
            //frmInfo dlg = new frmInfo();
            //dlg.Show();
            //this.Close();
        }

        void OnLoggedOff(SteamUser.LoggedOffCallback callback)
        {
            Console.WriteLine("Logged off of Steam: {0}", callback.Result);
            lstLog.Items.Add(String.Format("로그오프: {0}", callback.Result));
        }

        void OnMachineAuth(SteamUser.UpdateMachineAuthCallback callback, JobID jobId)
        {
            Console.WriteLine("보안 인증서 업데이트 중...");
           // lstLog.Items.Add("스팀가드 인증서 업데이트 중...");

            byte[] sentryHash = CryptoHelper.SHAHash(callback.Data);

            // write out our sentry file
            // ideally we'd want to write to the filename specified in the callback
            // but then this sample would require more code to find the correct sentry file to read during logon
            // for the sake of simplicity, we'll just use "sentry.bin"
            File.WriteAllBytes("sentry.bin", callback.Data);

            // inform the steam servers that we're accepting this sentry file
            steamUser.SendMachineAuthResponse(new SteamUser.MachineAuthDetails
            {
                JobID = jobId,

                FileName = callback.FileName,

                BytesWritten = callback.BytesToWrite,
                FileSize = callback.Data.Length,
                Offset = callback.Offset,

                Result = EResult.OK,
                LastError = 0,

                OneTimePassword = callback.OneTimePassword,

                SentryFileHash = sentryHash,
            });

            Console.WriteLine("업데이트 끝!");
            //lstLog.Items.Add("업데이트 끝!");

            //isRunning = false;
        }
#endregion




        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();
        private void Form1_Load(object sender, EventArgs e)
        {
         //   AllocConsole();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("종료하시겠습니까?", "Are you sure?", MessageBoxButtons.YesNo);

            // MessageBox 의 [예] 버튼 클릭시 발생하는 이벤트
            if (result == DialogResult.Yes)
            {
                Application.ExitThread();
                Environment.Exit(0);
            }

            // MessageBox 의 [아니오] 버튼이 클릭되었을 경우 - 이벤트 취소
            e.Cancel = (result == DialogResult.No);
        }




    }
}
