import React from "react";
import { Card, Image, Button } from "semantic-ui-react";
import { IActivity } from "../../../app/models/activity";

//fluid so it takes all the space of the 6 column grid
// button group make it evenly spaced
interface IProps {
  activity: IActivity;
}
const ActivityDetails: React.FC<IProps> = props => {
  const { activity } = props;
  return (
    <Card fluid>
      <Image src={`/assets/${activity.category}.jpg`} wrapped ui={false} />
      <Card.Content>
        <Card.Header>{activity.title}</Card.Header>
        <Card.Meta>
          <span className="date">{activity.date}</span>
        </Card.Meta>
        <Card.Description>{activity.description}</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <Button.Group widths={2}>
          <Button basic color="blue" content="edit" />
          <Button basic color="blue" content="cancle" />
        </Button.Group>
      </Card.Content>
    </Card>
  );
};

export default ActivityDetails;
