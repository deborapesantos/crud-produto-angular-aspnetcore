"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.APPSETTINGS = void 0;
var APPSETTINGS = /** @class */ (function () {
    function APPSETTINGS() {
    }
    APPSETTINGS.getBaseUrl = function () {
        return this.BaseURL;
    };
    APPSETTINGS.getBaseAuthUrl = function () {
        return this.BaseAuthUrl;
    };
    APPSETTINGS.BaseURL = window.location.origin;
    APPSETTINGS.BaseAuthUrl = "https://dev.sitemercado.com.br/api/login";
    return APPSETTINGS;
}());
exports.APPSETTINGS = APPSETTINGS;
//# sourceMappingURL=global-propertys.js.map