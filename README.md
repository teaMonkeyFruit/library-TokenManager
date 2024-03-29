# TeaMonkeyFruit.TokenManager

### A simple library for storing and retrieving access tokens from anywhere inside an asp.net core application using middleware and dependency injection.


When a request is received it is passed through the TokenManager middleware. Inside the middleware, the access token is retrieved from the HttpContext (Request Headers) and stored in a scoped lifetime service called `TokenManager`. TokenManager can then be injected into any service in the api that needs the access token. 

Few example uses cases: 
1. If you need to reuse the access token when calling another service.
2. If you need to extract user info from the access token for data storage, and you want to maintain seperation of concerns.


Example code:

Register the Middleware:
```

public class Startup 
{
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ...
            
            app.UseTokenManager();
            
            ...

        }
}
```

Register the Service:
```
public class Startup 
{
        public void ConfigureServices(IServiceCollection services)
        {
            ...
            
            services.AddTokenManager();

            ...
        }
}
```

Inject into constructor for use:
```

public class ApiClient
{
  private readonly ITokenManager _tokenManager;
  
    public ApiClient(ITokenManager tokenManager)
    {
       _tokenManager = tokenManager.Token;
    }

    public Item GetItemFromApi()
    {
       var token = _tokenManager.Token;
         
       ...
       
       return item;
    }
}

```
