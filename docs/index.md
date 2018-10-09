---
layout: default
---

## Overview

This document explains how to make a technical integration to the **MobilePay Invoice** product. The audience for this document is either technical integrators acting on behalf of merchants or merchants creating their own integrations.

### Related links:
- You can read more about the product [here](https://developer.mobilepay.dk/invoice-main/productinfo).
- Billing your customers with MobilePay Invoice is easy using our [API](https://developer.mobilepay.dk/product).
### QuickStart: follow our QuickStart to start building your integration
- More information about integration steps are [here](https://developer.mobilepay.dk/invoice-getting-started)
- Pick an OpenID Connect library: we recommend <a href="https://github.com/IdentityModel/IdentityModel.OidcClient2">Certified C#/NetStandard OpenID Connect Client Library for native mobile/desktop Applications</a> 
- Read the FAQ's for OpenID Connect <a href="https://developer.mobilepay.dk/faq/integrator">here</a>
- Integration is based on common standard OpenID Connect. You can find more [here](https://developer.mobilepay.dk/products/openid). 
- An example of how to use OpenID connect in C# can be found [here](https://github.com/MobilePayDev/MobilePay-Invoice/tree/master/ClientExamples)
- You can find links to the official Hybrid Flow [here](https://openid.net/specs/openid-connect-core-1_0.html#HybridFlowAuth).   
- See the video tutorial here [here](https://developer.mobilepay.dk/products/openid/video)


### OpenID flow
[![](assets/images/openid_flow_0.png)](assets/images/openid_flow_0.png)

### OpenID configuration endpoints 
Find the configuration links below:

|Environment | Links                               |
|-----------|------------------------------------------|
|Sandbox    | <a href="https://api.sandbox.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration">https://api.sandbox.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration</a> |
|Production   | <a href="https://api.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration">https://api.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration</a>      |
