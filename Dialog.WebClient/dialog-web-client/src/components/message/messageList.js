import React, { Component } from "react";
import Message from "./message";

export default class MessageList extends Component {
  render() {
    const { messages } = this.props;
    return (
      <div className="messages">
        {messages.map((message) => {
          return <Message message={message} />;
        })}
      </div>
    );
  }
}
