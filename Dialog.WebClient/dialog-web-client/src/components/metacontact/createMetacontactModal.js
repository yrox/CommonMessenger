import React, { Component } from "react";
import Modal from "react-modal";
import Select from "react-select";
import { Button, ButtonToolbar } from "react-bootstrap";
import { getContactsByType } from "../../dataMocks/mockAdapter";

export class CreateMetacontactModal extends Component {
  render() {
    const vkContacts = getContactsByType("vk");
    const telegramContacts = getContactsByType("telegram");

    return (
      <Modal
        isOpen={this.props.modalIsOpen}
        onRequestClose={this.props.changeModalState}
        style={customStyles}
        contentLabel="Create metacontact"
      >
        <h2 ref={subtitle => (this.subtitle = subtitle)}>Hello</h2>
        <div>
          <p>Telegram contacts</p>
          <Select
            options={telegramContacts.map(it => {
              return { value: it.id, label: it.name };
            })}
            value={null}
          />
        </div>
        <div>
          <p>Vk contacts</p>
          <Select
            options={vkContacts.map(it => {
              return { value: it.id, label: it.name };
            })}
            value={null}
          />
        </div>
        <ButtonToolbar>
          <Button bsStyle="primary" onClick={this.props.changeModalState}>
            Ok
          </Button>
          <Button onClick={this.props.changeModalState}>Cancel</Button>
        </ButtonToolbar>
      </Modal>
    );
  }
}
