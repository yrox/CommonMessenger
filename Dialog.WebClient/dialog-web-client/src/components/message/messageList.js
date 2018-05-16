import React, { Component } from "react";
import Message from "./message";

export default class MessageList extends Component {
  render() {
    const { messages } = this.props;
    return <div>{messages.map(mes => <div>{mes}</div>)}</div>;
  }
}
