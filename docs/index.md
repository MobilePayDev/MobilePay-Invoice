---
layout: default
---

## Overview of MobilePay Invoice integration 

This document explains how to make a technical integration to the **MobilePay Invoice** product. The audience for this document is either technical integrators acting on behalf of merchants or merchants creating their own integrations.


### OpenID flow
[![](assets/images/OpenIdflowWithFIandAuthorize.png)](assets/images/OpenIdflowWithFIandAuthorize.png)    
      

When user clicks on this button, merchant must do back-end call to   
[`"/authorize"`](https://developer.mobilepay.dk/products/openid/authorizeo) endpoint for initiating  authentication flow. You need to wait for the response by listening on the redirect URI and get the Authorization Code. Our system will re-direct the merchant back to your system also using the redirect URL. 
 
In short - The flow is described in the following 4 steps:

Step 1: Call /connect/authorize to initiate user login and consent

Step 2: Wait for the response by listening on the redirect URI and get the authorization code 

Step 3: Exchange the authorization code for tokens using /connect/token

Step 4: Keep the session alive by using the refresh token

### Best Practice

- Pick an OpenID Connect library: we recommend <a href="https://github.com/IdentityModel/IdentityModel.OidcClient2">Certified C#/NetStandard OpenID Connect Client Library for native mobile/desktop Applications</a> 
- Read the FAQ's for OpenID Connect <a href="https://developer.mobilepay.dk/faq/integrator">here</a>
- Integration is based on common standard OpenID Connect. You can find more [here](https://developer.mobilepay.dk/products/openid). 
- An example of how to use OpenID connect in C# can be found [here](https://github.com/MobilePayDev/MobilePay-Invoice/tree/master/ClientExamples)
- You can find links to the official Hybrid Flow [here](https://openid.net/specs/openid-connect-core-1_0.html#HybridFlowAuth).   
- See the video tutorial here [here](https://developer.mobilepay.dk/products/openid/video)
- You can read more about the product [here](https://developer.mobilepay.dk/invoice-main/productinfo).
* * *

### OpenID configuration endpoints 
Find the configuration links below:

|Environment | Links |
|------------|-------|
|Sandbox    | Denmark <a href="https://sandprod-admin.mobilepay.dk/account/.well-known/openid-configuration">https://sandprod-admin.mobilepay.dk/account/.well-known/openid-configuration</a> <br> Finland <a href="https://sandprod-admin.mobilepay.fi/account/.well-known/openid-configuration">https://sandprod-admin.mobilepay.fi/account/.well-known/openid-configuration</a> |
|Production  | Denmark <a href="https://admin.mobilepay.dk/account/.well-known/openid-configuration">https://admin.mobilepay.dk/account/.well-known/openid-configuration</a> <br> Finland <a href="https://admin.mobilepay.fi/account/.well-known/openid-configuration">https://admin.mobilepay.fi/account/.well-known/openid-configuration</a>|
