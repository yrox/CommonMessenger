import React, { Component } from "react";
import ChatPreview from "./chatPreview";

export default class ChatList extends Component {
  render() {
    const { chats, activeChat } = this.props;
    return (
      <div className="chats">
        {chats.map((chat, key) => {
          return (
            <div
              onClick={key => {
                this.props.setActiveChatId(chat.id);
              }}
              key={chat.id}
              className={classNames("chat", true, {
                active: _.get(activeChat, "id") === _.get(chat, "id", null)
              })}
            >
              <div className="user-image">{this.renderchatAvatars(chat)}</div>
              <div className="chat-info">
                <h2>{chat.name}</h2>
                {/* <p>{chat.messages[chat.messages.length - 1]}</p> */}
              </div>
            </div>
          );
        })}
      </div>
    );
  }
}
