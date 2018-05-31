---
layout: default
---

## Overview

Billing your customers with *MobilePay Invoice* is easy using our [API](https://developer.mobilepay.dk/node/1301).<br />
This document explains how to make a technical integration to the *MobilePay Invoice* product. The audience for this document is either technical integrators acting on behalf of merchants or merchants creating their own integrations.

### <a name="where-available"/> Where is it available ?

- Denmark
- Finland

### <a name="merchant-onboarding"/> Merchant onboarding

As a merchant wanting to send invoices via MobilePay, you enrol to the product in MobilePay Portal [Denmark](https://admin.mobilepay.dk) or [Finland](https://admin.mobilepay.fi). Here you will find information about our products as well as an easy way of enrolling. As an integrator or 3rd party service provider acting on behalf of a merchant, you need your customer to enrol to the product prior to doing the integration. During the first product enrolment, you, as a merchant, will be requested details about your company such as company size, type etc. You will also be asked to confirm the account(s) you wish to use. This information is required in order for us to verify your company information to be able to transfer the money to you securely.

During the enrolment you will also be given the option to define parameters such as name, logo, address, etc. for how your MobilePay Invoice Issuer should reflect your company in MobilePay. You can have more than one Invoice issuer to represent your company structure.

### <a name="integration-steps"/> Integration steps

Integrating to MobilePay Invoice is a multistep process which involves subscribing to the [invoice product](https://developer.mobilepay.dk/node/1302), developing a client application and using it to call endpoints of our API. To start integration you need to be onboarded first (read previous section).

In the sections below, the following steps of integration will be explained:

1.	Subscribing to the Invoice product through the API gateway.
2.	Using OpenID Connect enabling integrators to call the invoice API on-behalf of merchants.
3.	How does the Invoice API look like and how is it called.

<a name="apigateway"/>  

### API Gateway     

The first step needed in order to integrate to MobilePay invoice is obtaining access to the sandbox environment. The sandbox environment is a production like environment used in MobilePay to test technical integrations. The environment is located [here](https://sandbox-developer.mobilepay.dk/).<br />

Make sure that it is clear that the invoice product is wanted when requesting access. Once logged in, create an app representing your application. This will yield a client id and a secret -remember these as they are needed in every call. After this, navigate to the invoice product and subscribe with your newly created app. All facilities and information for testing connection will be available inside the sandbox environment when logged in.

<a name="openidconnect"/>  

### OpenID Connect

When the merchant is onboarded, he has a user in MobilePay that is able to manage which products the merchant wishes to use. Not all merchants have the technical capabilities to make integrations to MobilePay, instead they may need to go through applications whith these capabilities. In order for this to work, the merchant must grant consent to an application with these capabilities. This consent is granted through mechanism in the [OpenID Connect](http://openid.net/connect/) protocol suite.<br />

The OpenID Connect protocol is a simple identity layer on top of the OAuth 2.0 protocol. Integrators are the same as clients in the OAuth 2.0 protocol. The first thing that must be done as a client is to go and register [here]( https://www.mobilepay.dk/da-dk/Erhverv/Pages/MobilePay-integrator.aspx). Once this is done the client must initiate the [hybrid flow](http://openid.net/specs/openid-connect-core-1_0.html#HybridFlowAuth) specified in OpenID connect. For invoices the client must request consent from the merchant using the 'invoice' scope. The authorization server in sandbox is located  https://sandprod-admin.mobilepay.dk/account/connect/authorize <br />

If the merchant grants consent, an authorization code is returned which the client must exchange for an id token, an access token and a refresh token. The refresh token is used to refresh ended sessions without asking for merchant consent again. This means that if the client receives an answer from the api gateway saying that the access token is invalid, the refresh token is exchanged for a new access token and refresh token.

An example of how to use OpenID connect in C# can be found [here](https://github.com/MobilePayDev/MobilePay-Invoice/tree/master/ClientExamples).

### <a name="openid-flow"></a> OpenID flow
[![](assets/images/openid_flow_0.png)](assets/images/openid_flow_0.png)

### <a name="supported-endpoints"></a> Supported Endpoints 
Find the supported endpoints in the links below 

|Environment | Links                               |
|-----------|------------------------------------------|
|Sandbox    | <a href="https://api.sandbox.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration">https://api.sandbox.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration</a> |
|Production   | <a href="https://api.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration">https://api.mobilepay.dk/merchant-authentication-openidconnect/.well-known/openid-configuration</a>      |