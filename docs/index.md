---
layout: default
---

## Overview

This document explains how to make a technical integration to the **MobilePay Invoice** product. The audience for this document is either technical integrators acting on behalf of merchants or merchants creating their own integrations.

Related links:
- You can read more about the product [here](https://developer.mobilepay.dk/invoice-main/productinfo).
- Billing your customers with MobilePay Invoice is easy using our [API](https://developer.mobilepay.dk/node/1302).
- More information about integration steps is [here](https://developer.mobilepay.dk/invoice-getting-started).
- Integration is based on common standard OpenID Connect. You can find more [here](https://developer.mobilepay.dk/products/openid). An example of how to use OpenID connect in C# can be found [here](https://github.com/MobilePayDev/MobilePay-Invoice/tree/master/ClientExamples). You can find links to the official Hybrid Flow [here](https://openid.net/specs/openid-connect-core-1_0.html#HybridFlowAuth).   

### OpenID flow
[![](assets/images/openid_flow_0.png)](assets/images/openid_flow_0.png)

### OpenID configuration endpoints 
Find the configuration links below:

|Environment | Links                               |
|-----------|------------------------------------------|
|Sandbox    | <a href="https://api.sandbox.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration">https://api.sandbox.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration</a> |
|Production   | <a href="https://api.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration">https://api.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration</a>      |