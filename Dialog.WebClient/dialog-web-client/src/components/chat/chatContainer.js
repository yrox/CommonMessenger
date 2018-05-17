import React, { Component } from "react";
import classNames from "classnames";
import _ from "lodash";
import moment from "moment";
import MetacontactList from "../metacontact/metacontactList";
import ChatInputArea from "./chatInputArea";
import MessageList from "../message/messageList";
import ChatList from "../chat/chatList";
import CreateMetacontactModal from "../metacontact/createMetacontactModal";
import {
  getAllMessages,
  getMessagesByMetacontact
} from "../../dataMocks/mockAdapter";

export default class Messenger extends Component {
  constructor(props) {
    super(props);

    this.state = {
      newMessage: "Hello there...",
      activeChat: null,
      modalIsOpen: false
    };

    this.handleSend = this.handleSend.bind(this);
    this.onInputChange = this.onInputChange.bind(this);
    this.scrollMessagesToBottom = this.scrollMessagesToBottom.bind(this);
    this.onCreateMetacontact = this.onCreateMetacontact.bind(this);
    this.changeModalState = this.changeModalState.bind(this);
  }

  changeModalState() {
    this.setState({ modalIsOpen: !this.state.modalIsOpen });
  }

  onCreateMetacontact() {
    const channel = {
      title: "",
      lastMessage: "",
      isNew: true,
      userId: currentUserId,
      created: new Date()
    };
  }

  scrollMessagesToBottom() {
    if (this.messagesRef) {
      this.messagesRef.scrollTop = this.messagesRef.scrollHeight;
    }
  }

  setActiveChatId(newValue) {
    this.setState({
      activeChat: newValue
    });
  }

  handleSend() {
    const { newMessage } = this.state;

    if (_.trim(newMessage).length) {
      const messageId = new ObjectID().toString();

      const message = {
        id: messageId,
        meta: this.state.activeChat.metacontact,
        text: newMessage,
        date: moment.now(),
        me: true
      };
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

  componentDidUpdate() {
    this.scrollMessagesToBottom();
  }

  componentDidMount() {}

  componentWillUnmount() {}

  render() {
    const metcontacts = getAllMetacontacts();
    const activeChat = metacontacts[0];
    const messages = getMessagesByMetacontact(activeChat);

    return (
      <div style={style} className="app-messenger">
        <CreateMetacontactModal
          isModalOpen={this.state.modalIsOpen}
          changeModalState={this.changeModalState}
        />
        <div className="header">
          <div className="left">
            <button className="left-action">
              <i className="icon-settings-streamline-1" />
            </button>
            <button onClick={this.onCreateMetacontact} className="right-action">
              <i className="icon-edit-modify-streamline" />
            </button>
            <h2>Messenger</h2>
          </div>
          <div className="content">
            <h2>{activeChat.metacontact.name}</h2>
          </div>
        </div>
        <div className="main">
          <div className="sidebar-left">
            <ChatList
              chats={metacontacts}
              activeChat={activeChat}
              setActiveChatId={this.setActiveChatId}
            />
          </div>
          <div className="content">
            <MessageList messages={messages} messagesRef={this.messagesRef} />

            {activeChat && metcontacts.size > 0 ? (
              <ChatInputArea
                handleSend={this.handleSend}
                onInputChange={this.onInputChange}
              />
            ) : null}
          </div>
          <div className="sidebar-right">
            <MetacontactList metacontacts={metacontacts} />
          </div>
          <div>
            <button onClick={this.changeModalState}>Create metacontact</button>
          </div>
        </div>
      </div>
    );
  }
}
