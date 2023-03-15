import { ServiceSettings } from "./service-settings";
import { User } from "./user";

export class ApplicationState {
  constructor() {
    this.IsloggedIn = false;
    this.User = new User();
    this.ServicesSettings = new Array<ServiceSettings>();
  }
  public IsloggedIn: boolean;
  public User: User;
  public ServicesSettings: Array<ServiceSettings>;
}
