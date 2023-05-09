// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using eCommerce.IdentityServer.MainModule.Consent;

namespace eCommerce.IdentityServer.MainModule.Device
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}