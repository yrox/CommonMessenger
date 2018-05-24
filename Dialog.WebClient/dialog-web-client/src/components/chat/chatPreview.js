import React, { Component } from "react";
import classNames from "classnames";
import _ from "lodash";

export default class ChatPreview extends Component {
  render() {
    const { activeChat, chat } = this.props;
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
        {/* <div className="user-image">{this.renderchatAvatars(chat)}</div> */} 
        <div className="chat-info">
          <h2>{chat.name}</h2>
        </div>
      </div>
    );
  }
}
