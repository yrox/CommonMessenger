import React, { Component } from "react";
import Metacontact from "./metacontact";
import classNames from "classnames";

export default class MetacontactList extends Component {
  render() {
    const { metacontacts } = this.props;

    return (
      <div>
        {metacontacts.size > 0 ? (
          <div>
            <h2 className="title">Metacontacts</h2>
            <div className="metacontacts">
              {metacontacts.map((metacontact, key) => {
                <Metacontact metacontact={metacontact} key={key} />;
              })}
            </div>
          </div>
        ) : null}
      </div>
    );
  }
}
