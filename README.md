# AbpCommunityTalks
ABP Community Talks Demo


## Running the HttpApi.Host

- Install [ngrok](https://ngrok.com/) if you haven't.

- Expose `https://localhost:44380` with ngrok
  ```bash
  ngrok http https://localhost:44380
  ```
  
- You'll see an endpoint, something like 'https://XXX-XXX-XX.eu.ngrok.io', copy that and configure in following files:
  - **AbpCommunityTalks.HttpApi.Host/appsettings.json**
    - `App:SelfUrl`
    - `AuthServer:Authority`,
    - `ValidIssuers`
  - **AbpCommunityTalks.Maui/appsettings.json** 
    - `Oidc:Options:Authority`
    - `RemoteServices:Default:BaseUrl`

- Run the `AbpCommunityTalks.DbMigrator` before launch HttpApi.Host once.

- Run the `AbpCommunityTalks.HttpApi.Host` application.

## Running the Maui Application

If you complete first **'Running the HttpApi.Host'**, you're ready to run Maui application. Just run it with Visual Studio.
