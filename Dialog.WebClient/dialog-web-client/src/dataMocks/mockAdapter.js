export function getAllAccounts() {
  return require("./accounts.json");
}

export function getAllMessages() {
  return require("./messages.json");
}

export function getAllContacts() {
  return require("./contacts.json");
}

export function getAllMetacontacts() {
  return require("./metacontacts.json");
}

export function getContactsByType(type) {
  return getAllContacts().filter(it => it.type === type);
}

export function getMessagesByMetacontact(metacontact) {
    return getAllMessages().filter(it => it.meta.id === metacontact.id);
}