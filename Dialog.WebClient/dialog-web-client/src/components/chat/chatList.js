import React, { Component } from "react";
import ChatPreview from "./chatPreview";

export default class ChatList extends Component {
  render() {
    const { chats, activeChat, setActiveChatId } = this.props;
    return (
      <div className="chats">
        {chats.map((chat) => {
          return (
            <ChatPreview
              chat={chat}
              activeChat={activeChat}
              setActiveChatId={setActiveChatId}
            />
          );
        })}
      </div>
    );
  }
}
