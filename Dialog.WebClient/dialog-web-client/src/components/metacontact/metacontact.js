import React, { Component } from "react";
import classNames from 'classnames';

export default class Metacontact extends Component {
  render() {
    const { metacontact, key } = this.props;
    const isOnline = true; // TODO: get metacontact status

    return (
      <div key={key} className="metacontact">
        <div className="user-image">
          <img alt="" />
          <span
            className={classNames("user-status", {
              online: isOnline
            })}
          />
        </div>
        <div className="metacontact-info">
          <h2>
            {metacontact.name} -{" "}
            <span
              className={classNames("user-status", {
                online: isOnline
              })}
            >
              {isOnline ? "Online" : "Offline"}
            </span>{" "}
          </h2>
        </div>
      </div>
    );
  }
}
