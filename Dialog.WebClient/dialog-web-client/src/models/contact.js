export class Contact {
    constructor(id, name, phone, contactId, type, meta) {
        this.id = id;
        this.name = name;
        this.contactIdentifier = contactId;
        this.type = type;
        this.metaContact = meta;
    }
}