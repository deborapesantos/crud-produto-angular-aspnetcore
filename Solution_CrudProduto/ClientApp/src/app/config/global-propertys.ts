export class APPSETTINGS {

  private static BaseURL: string = window.location.origin;
  private static BaseAuthUrl = "https://dev.sitemercado.com.br/api/login";

  public static getBaseUrl() {
    return this.BaseURL;
  }

  public static getBaseAuthUrl() {
    return this.BaseAuthUrl;
  }

}
