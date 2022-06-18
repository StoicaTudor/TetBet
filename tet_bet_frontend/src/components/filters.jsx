import React, { Component } from "react";
import { Dropdown } from "react-bootstrap";

class Filters extends Component {
  state = {
    selection: null,
  };

  filterSelectionChanged = (selection) => {
    this.setState({ selection });
    this.props.onSelection(selection);
  };

  // forceSetSelectionValue = (selection) =>
  //   this.setState

  render() {
    return (
      <React.Fragment>
        {Object.keys(this.props.elements).length > 0 && (
          <Dropdown>
            <Dropdown.Toggle variant="success">
              {this.state.selection === null
                ? this.props.elements[0].name
                : this.state.selection.name}
            </Dropdown.Toggle>

            <Dropdown.Menu>
              {this.props.elements.map((element) => (
                <Dropdown.Item
                  onClick={() => {
                    this.filterSelectionChanged(element);
                  }}
                >
                  {element.name}
                </Dropdown.Item>
              ))}
            </Dropdown.Menu>
          </Dropdown>
        )}
      </React.Fragment>
    );
  }
}

export default Filters;
