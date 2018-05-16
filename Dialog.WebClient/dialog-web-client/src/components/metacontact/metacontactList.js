import React, { Component } from "react";
import Metacontact from './metacontact';

export default class MetacontactList extends Component {
  render() {
    const { metacotacts} = this.props;
    return <div>{metacotacts.map(mc => <div>{mc}</div>)}</div>;
  }
}
