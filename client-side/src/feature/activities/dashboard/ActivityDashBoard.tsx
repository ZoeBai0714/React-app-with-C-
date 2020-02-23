import React from "react";
import { Grid, List } from "semantic-ui-react";
import { IActivity } from "../../../app/models/activity";
import ActivityList from "./ActivityList";

interface IProps {
  activities: IActivity[];
}
const ActivityDashBoard: React.FC<IProps> = props => {
  const { activities } = props;
  return (
    <Grid>
      <Grid.Column width={10}>
        <ActivityList activities={activities} />
        {/* <List>
          {activities.map(activity => (
            <List.Item key={activity.id}>{activity.title}</List.Item>
          ))}
        </List> */}
      </Grid.Column>
    </Grid>
  );
};

export default ActivityDashBoard;
