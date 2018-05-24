import React, { Component } from "react";
import _ from 'lodash';

export default class ChatInputArea extends Component {
  render() {
    return (
      <div className="messenger-input">
        <div className="text-input">
          <textarea
            onKeyUp={event => {
              if (event.key === "Enter" && !event.shiftKey) {
                this.props.handleSend();
              }
            }}
            onChange={event => {
              const newMessage = _.get(event, "target.value");

              this.setState({ newMessage: newMessage });
              this.props.onInputChange({
                newMessage: newMessage
              });
            }}
            value=''
            placeholder="Write your messsage..."
          />
        </div>
        <div className="actions">
          <button onClick={this.props.handleSend} className="send">
            Send
          </button>
        </div>
      </div>
    );
  }
}
