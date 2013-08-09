TwoFactor.NET
===========

TwoFactor.NET is a library that provides support for the creation and use of One Time Passwords using the HOTP (HMAC One Time Password) and TOTP (Time Based One Time Password) algorithms.

This code is based upon the following RFCs

* [RFC 2289 - A One-Time Password System](http://tools.ietf.org/html/rfc2289)
* [RFC 4226 - An HMAC-Based One-Time Password Algorithm](http://tools.ietf.org/html/rfc4226) 
* [RFC 6238 - Time-Based One-Time Password Algorithm](http://tools.ietf.org/html/rfc6238)

This library should be compatible with all TOTP based client generators but has been tested and verified with the following clients

 * Google Authenticator ([Android](https://play.google.com/store/apps/details?id=com.google.android.apps.authenticator2))

Developed and maintained by [Alan Barber](http://alanbarber.com) but [Contributors](CONTRIBUTORS.md) are always welcome!

Quick Links
-----------
[Project Website](http://github.com/alanbarber/TwoFactorNet)
[Source Code](http://github.com/alanbarber/TwoFactorNet)
[Documentation](http://github.com/alanbarber/TwoFactorNet/wiki)
[Work Items and Bug Tracker](http://github.com/alanbarber/TwoFactorNet/issues)

Installation
------------

**[Release Notes & Changes](RELEASENOTES.md)**

Manual Install

1. Download the project
2. Compile the project
3. Copy the DLL to your project and add a reference to it

NuGet Install

_NuGet packages have not been created and uploaded yet._

Usage
-----

Here is a basic pattern for setting up and using TwoFactor.NET with a TOTP

First you should generate the secret key (this is a 80bit or 16 char base32 string) and provide it to the user to add to their
client either by manually typing in the 16 char string or generating a QR code they can scan.

Save this secret key for the user and for you to be able to verify the user in the future.

When the user logs on you should ask for their 6 digit auth code. using the secret key run it through the time based process
and verify that it matches the provided code the user enters.

QR Code Generation
------------------

This library does not provide tools to generate QR Codes. There are many very 
good open source libraries to generate the codes.

A well maintained and easy to use one is [ZXing.NET](http://zxingnet.codeplex.com/)

The Text String you should use to create the QR Code is as follows:

TOPT (Time Based One Time Password)
otpauth://topt/{IssuerName}:{AccountName}?secret={SecretKey}&issuer={IssuerName}

HOTP (HMAC-based One Time Password)
otpauth://hopt/{IssuerName}:{AccountName}?secret={SecretKey}&counter={Counter}&issuer={IssuerName}

Best Practices
--------------

Do not rely on a single method of Two-Factor Authentication as it limits the adoption. Provide multiple options such as sending a code via sms or email.

Always offer users the ability to generate backup one time use codes. The easiest way is to generate 6 codes using time or counter 0-5 

It can be helpful to perform relaxed verification for TOTP that validates the users code against, current time block, previous time block and next time block.
This allows for some time drift between the user and server to cut down on failed login errors.

HOTP codes can become out of sync if the user accidentally clicks the refresh code on a client thus getting their counter
out of sync with your server counter. If this happen you can attempt to resync the counter by asking the user to generate 3 sequential
codes and enter them at the same time in order 1,2,3. Then you run up the counter in a loop until you catch up and match the 3 codes. thus
you now have figured out where the client counter is. you should limit the runup to counter + 100 to prevent an infinite loop of generation 
if the user didn't type in a code correctly.

License
-------

TwoFactor.NET is covered under the terms of the [Apache 2.0 License](LICENSE.md)



