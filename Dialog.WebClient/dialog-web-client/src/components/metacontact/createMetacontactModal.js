import React, { Component } from "react";
import { Button, Modal } from "react-bootstrap";
import Select from "react-select";
import { getContactsByType } from "../../dataMocks/mockAdapter";
import 'react-select/dist/react-select.css';

export class CreateMetacontactModal extends Component {
  render() {
    const vkContacts = getContactsByType("vk");
    const telegramContacts = getContactsByType("telegram");

    return (
      <Modal.Dialog
        show={this.props.isModalOpen}
        onHide={this.props.changeModalState}
      >
        <Modal.Header className="centered-container">
          <Modal.Title classname="centered-child">
            Create New Metacontact
          </Modal.Title>
        </Modal.Header>
        <Modal.Body className="centered-container">
          <div className="centered-child">
            <div>
              <p className="contact-list-title">Telegram contacts</p>
              <Select
                options={telegramContacts.map(it => {
                  return { value: it.id, label: it.name };
                })}
              />
            </div>
            <div>
              <p className="contact-list-title">Vk contacts</p>
              <Select
                options={vkContacts.map(it => {
                  return { value: it.id, label: it.name };
                })}
              />
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer>
          <Button
            className="btn btn-primary"
            onClick={this.props.changeModalState}
          >
            Ok
          </Button>
          <Button onClick={this.props.changeModalState}>Cancel</Button>
        </Modal.Footer>
      </Modal.Dialog>
    );
  }
}
