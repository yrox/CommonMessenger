import React, { Component } from "react";
import classNames from 'classnames';
import _ from 'lodash';

export default class ChatPreview extends Component {
  render() {
    const { name } = this.props;
    return (
      <div
        onClick={key => {
          this.props.setActiveChannelId(channel._id);
        }}
        key={channel._id}
        className={classNames(
          "chanel",
          { notify: _.get(channel, "notify") === true },
          {
            active: _.get(activeChannel, "_id") === _.get(channel, "_id", null)
          }
        )}
      >
        <div className="user-image">{this.renderChannelAvatars(channel)}</div>
        <div className="chanel-info">
          {this.renderChannelTitle(channel)}
          <p>{channel.lastMessage}</p>
        </div>
      </div>
    );
  }
}
