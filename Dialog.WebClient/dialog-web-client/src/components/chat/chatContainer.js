import React, { Component } from "react";
import _ from "lodash";
import ChatInputArea from "./chatInputArea";
import MessageList from "../message/messageList";
import ChatList from "../chat/chatList";
import { CreateMetacontactModal } from "../metacontact/createMetacontactModal";
import {
  getAllMetacontacts,
  getMessagesByMetacontact
} from "../../dataMocks/mockAdapter";
import { Button } from "react-bootstrap";
import Select from 'react-select';

export default class ChatContainer extends Component {
  constructor(props) {
    super(props);

    this.state = {
      newMessage: "Hello there...",
      activeChat: null,
      modalIsOpen: false
    };

    this.handleSend = this.handleSend.bind(this);
    this.onInputChange = this.onInputChange.bind(this);
    // this.onCreateMetacontact = this.onCreateMetacontact.bind(this);
    this.changeModalState = this.changeModalState.bind(this);
  }

  changeModalState() {
    this.setState({ modalIsOpen: !this.state.modalIsOpen });
  }

  // onCreateMetacontact() { TODO: implement metacontact creation logic
  //   const channel = {
  //     title: "",
  //     lastMessage: "",
  //     isNew: true,
  //     userId: currentUserId,
  //     created: new Date()
  //   };
  // }

  setActiveChatId(newValue) {
    this.setState({
      activeChat: newValue
    });
  }

  handleSend() {
    const { newMessage } = this.state;

    if (_.trim(newMessage).length) {
      // const messageId = Math.random();

      // const message = {
      //   id: messageId,
      //   meta: this.state.activeChat.metacontact,
      //   text: newMessage,
      //   date: moment.now(),
      //   me: true
      // };
      // store.addMessage(messageId, message); TODO: remove mock

      this.setState({
        newMessage: ""
      });
    }
  }

  onInputChange(newValue) {
    this.setState({
      newMessage: newValue
    });
  }

  render() {
    const metacontacts = getAllMetacontacts();
    const activeChat = metacontacts[0];
    const messages = getMessagesByMetacontact(activeChat);

    return (
      <div className="app-messenger">
        <CreateMetacontactModal
          isModalOpen={this.state.modalIsOpen}
          changeModalState={this.changeModalState}
        />
        <div className="header">
          <div className="left">
            {/* <button className="left-action">
              <i className="icon-settings-streamline-1" />
            </button> */}
            {/* <button onClick={this.onCreateMetacontact} className="right-action">
              <i className="icon-edit-modify-streamline" />
            </button> */}
            <h2>Dialog</h2>
          </div>
          <div className="content">
            <h2>{activeChat.name}</h2>
          </div>
        </div>
        <div className="main">
          <div className="sidebar-left">
            <ChatList
              chats={metacontacts}
              activeChat={activeChat}
              setActiveChatId={this.setActiveChatId}
            />
            <div className="centered-container">
              <Button
                type="primary"
                className="btn btn-primary centered-child"
                onClick={this.changeModalState}
              >
                Create metacontact
              </Button>
            </div>
          </div>
          <div className="content">
            <MessageList messages={messages} messagesRef={this.messagesRef} />

            {activeChat ? (
              <ChatInputArea
                handleSend={this.handleSend}
                onInputChange={this.onInputChange}
              />
            ) : null}
          </div>
        </div>
      </div>
    );
  }
}
