# OIDC 定义步骤

### 1、定义 API 资源 ApiResources

- 1、Authority 配置授权服务的地址
- 2、Audience 配置 api 的观众，即是 api 的 scope

``` c#
services.AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.Authority = adminApiConfiguration.IdentityServerBaseUrl;
        options.RequireHttpsMetadata = adminApiConfiguration.RequireHttpsMetadata;
        options.Audience = adminApiConfiguration.OidcApiName;
    });
```

### 2、定义客户端 Clients

- 1、ClientId 配置客户端ID
- 2、ClientName 配置 客户端显示的名字
- 3、AllowedGrantTypes 允许的授权类型
- 4、AllowedScopes 允许的范围
- 5、PostLogoutRedirectUris 服务器端注销通道
- 6、FrontChannelLogoutUri 前端注销通道
- 7、RequirePkce 支持 Pkce



### 3、定义授权服务器 IdentityServer

- 1、AddConfigurationStore 配置 IdentityServer 配置存储
- 2、AddAspNetIdentity 配置 AspNetIdentity 身份验证存储

api 定义到哪里验证用户，即它要关联 IdentityServer
client 定义用户可以访问哪些资源（scope）


# 创建和还原数据库

- 到Skoruba.IdentityServer4.Admin目录下执行 dotnet ef database update -c AdminIdentityDbContext AdminLogDbContext IdentityServerConfigurationDbContext IdentityServerPersistedGrantDbContext IdentityServerDataProtectionDbContext AdminAuditLogDbContext







