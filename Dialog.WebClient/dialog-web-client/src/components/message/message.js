import React, { Component } from "react";

export default class Message extends Component {
  render() {
    const { text, date, author } = this.props;
    return (
      <div>
        <div>author</div>
        <div>text</div>
        <div>date</div>
      </div>
    );
  }
}
