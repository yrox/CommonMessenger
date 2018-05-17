import React, { Component } from "react";
import Message from "./message";

export default class MessageList extends Component {
  render() {
    const { messages } = this.props;
    return (
      <div ref={ref => (this.messagesRef = ref)} className="messages">
        {messages.map((message, index) => {
          return <Message index={index} message={message} />;
        })}
      </div>
    );
  }
}
