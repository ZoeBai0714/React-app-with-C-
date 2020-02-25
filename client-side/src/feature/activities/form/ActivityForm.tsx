import React from "react";
import { Segment, Form, Button } from "semantic-ui-react";
interface Iprops {
  setEditMode: (editMode: boolean) => void;
}

const ActivityForm: React.FC<Iprops> = props => {
  const { setEditMode } = props;
  return (
    <Segment clearing>
      <Form>
        <Form.Input placeholder="title" />
        <Form.TextArea rows={2} placeholder="Description" />
        <Form.Input placeholder="Category" />
        <Form.Input type="date" placeholder="Date" />
        <Form.Input placeholder="City" />
        <Form.Input placeholder="Venue" />
        <Button floated="right" positive type="submit" content="submit" />
        <Button
          floated="right"
          type="button"
          content="cancle"
          onClick={() => setEditMode(false)}
        />
      </Form>
    </Segment>
  );
};

export default ActivityForm;
