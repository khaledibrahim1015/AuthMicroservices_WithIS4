# AuthMicroservices_WithIS4

## Overall Picture
secure microservices with using standalone Identity Server 4 and backing with Ocelot API Gateway. protecting ASP.NET Web MVC and API applications with using OAuth 2 and OpenID Connect in IdentityServer4. Securing your web application and API with tokens, working with claims, authentication and authorization middlewares and applying policies

![Arch](https://github.com/user-attachments/assets/894a1f00-f07e-4f00-8595-e39d66c52c98)

## Movies.API

develop Movies.API project and protect this API resources with IdentityServer4 OAuth 2.0 implementation. Generate JWT Token with client_credentials from IdentityServer4 and use this token for securing Movies.API protected resources.

## Movies.MVC

develop Movies.MVC Asp.Net project for Interactive Client of our application. This Interactive Movies.MVC Client application will be secured with OpenID Connect in IdentityServer4. Our client application pass credentials with logging to an Identity Server and receive back a JSON Web Token (JWT).

## Identity Server

develop centralized standalone Authentication Server and Identity Provider with implementing IdentityServer4 package and the name of microservice is Identity Server. Identity Server4 is an open source framework which implements OpenId Connect and OAuth2 protocols for .Net Core. With Identity Server, provide authentication and access control for  Web APIs from a single point between applications or on a user basis.

## Ocelot API Gateway

 develop Ocelot API Gateway and make secure protected API resources over the Ocelot API Gateway with transferring JWT web tokens. Once the client has a bearer token it will call the API endpoint which is fronted by Ocelot. Ocelot is working as a reverse proxy. After Ocelot reroutes the request to the internal API, it will present the token to Identity Server in the authorization pipeline. If the client is authorized the request will be processed and a list of movies will be sent back to the client.

Also apply the claim based authentications.
