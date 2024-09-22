# SwitchBoard-API
Dotnet minimal API that interacts with Supabase built for storing and interacting with a database of mechanical keyboard switches.

## How to Run
Clone repo and open directory

```
git clone https://github.com/IllusiveBagel/SwitchBoard-API.git
cd SwitchBoard-API
```
Next you need to modify the config file to configure both the Supabase connection and the Supabase authentication service. This modification can either be done to appsettings.json or you can copy the existing appsettings.json and create appsettings.Development.json.

The first section that needs to be configured is the Supabase connection. This section has 2 values: URL and Key. These can both be found on the home page of your Supabase project under the heading "Connecting to your project".

The next section that needs to be configured is the Authentication section of appsettings. This section has 3 required value: ValidIssuer, ValidAudience and JwtSecret. The Valid Issuer is formatted like ```{Supabase URL}/auth/v1```. The ValidAudience is related to the roles that are assigned to the users for now we only have 1 role ```authenticated```. This value may change in the future. and the final value is the JwtSecret this value can be aquired by going to the SQLEditor in your project and running this code ```show app.settings.jwt_secret``` and that will return your JwtSecret. It's important to keep this value a secret and not commit it anywhere.

```
{
  "supabase": {
    "URL": "{Supabase URL}",
    "Key": "{Supabase Key}"
  },
  "Authentication": {
    "ValidIssuer": "{Supabase URL}/auth/v1",
    "ValidAudience": "authenticated",
    "JwtSecret": "{JwtSecret}"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

Once the appsettings has all those values you're ready to run the code which can be done by running the following line in the command line.

```dotnet run```

Once the code is running you can go to the displayed URL in the command line and add ```/swagger``` at the end of the URL to see the swagger docs.