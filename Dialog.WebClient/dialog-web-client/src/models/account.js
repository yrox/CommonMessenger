export class Account {
  constructor(id, login, password, phone, accId, type) {
    this.id = id;
    this.login = login;
    this.password = password;
    this.phoneNumber = phone;
    this.accountIdentifier = accId;
    this.type = type;
  }
}
