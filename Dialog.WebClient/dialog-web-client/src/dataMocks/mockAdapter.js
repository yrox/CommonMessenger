import { readFile, readAsText } from "fs";

export function getAllAccounts() {
  return JSON.parse(readFile("./accounts.json"));
}

export function getAllMessages() {
  return JSON.parse(readFile("./messages.json"));
}

export function getAllContacts() {
  return JSON.parse(readFile("./contacts.json"));
}

export function getAllMetacontacts() {
  return JSON.parse(readFile("./metacontacts.json"));
}

export function getContactsByType(type) {
  return getAllContacts().filter(it => it.type === type);
}

export function getMessagesByMetacontact(metacontact) {
    return getAllMessages().filter(it => it.meta.id === metacontact.id);
}