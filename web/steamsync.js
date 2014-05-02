Parse.initialize("5qeL512r6WzBuHnxGhMKLNNj0tUCBAI26FPN4TRl", "U5mTvHIBzvADVordDi15nQU6RACc4PVxaFa22Spa");

var TestObject = Parse.Object.extend("TestObject");
var testObject = new TestObject();

testObject.save({foo: "bar"}).then(function(object)
{
  alert("yay! it worked");
});
