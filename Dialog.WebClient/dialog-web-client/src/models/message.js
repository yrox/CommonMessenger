export class Message {
  constructor(id, text, date, type, contactId, meta) {
    this.id = id;
    this.text = text;
    this.date = date;
    this.type = type;
    this.contactIdentifier = contactId;
    this.metaContact = meta;
  }
}
