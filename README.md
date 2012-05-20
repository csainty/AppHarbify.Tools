#AppHarbify.Tools
AppHarbify.Tools is a collection of small nuget packages that help make your software deployable to AppHarbor by AppHarbify.

##AppHarbify.EF
A common pattern with EF is to define your DataContext like so.

````
public class FooContext : DbContext {  
    public FooContext() : base ("Foo")  
}  
````
Which then, by convention, picks up a connection string named `Foo`.

This doesn't work very well for AppHarbify as by default on AppHarbor, the connection string lives in an `AppSetting` called `SQLSERVER_CONNECTION_STRING`.

AppHarbify.EF makes it really simple to override this convention when it detects the `AppSetting`, leaving it alone when it does not, so that with a single line of code you can support running on AppHarbor with no setup.

First install the [package](http://nuget.org/packages/AppHarbify.EF) `Install-Package AppHarbify.EF`  
Then add the following line of code somewhere in your app startup process.

````
AppHarbify.EF.ConnectionFactory.Enable();
````

You can also enable `MultipleActiveResultSets` by simply passing in true, which will append `MultipleActiveResultSets=True;` to the connection string provided by AppHarbor.

````
AppHarbify.EF.ConnectionFactory.Enable(true);
````



##See Also
* [AppHarbify](http://appharbify.com)
* [AppHarbor](http://appharbor.com)
* [@csainty](http://twitter.com/csainty) - [blog](http://blog.csainty.com)

