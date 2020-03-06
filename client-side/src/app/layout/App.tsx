import React, { useState, useEffect, Fragment } from "react";
import NavBar from "../../feature/NavBar";
import { Container } from "semantic-ui-react";
import { IActivity } from "../models/activity";
import ActivityDashBoard from "../../feature/activities/dashboard/ActivityDashBoard";
import agent from "../api/agent";

const App = () => {
  const [activities, setActivities] = useState<IActivity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<IActivity | null>(
    null
  );
  const [editMode, setEditMode] = useState(false);
  const handleSelectActivity = (id: string) => {
    setSelectedActivity(activities.filter(activity => activity.id === id)[0]);
    setEditMode(false);
  };

  const handleOpenCreateForm = () => {
    setSelectedActivity(null);
    setEditMode(true);
  };

  const handleCreateActivity = (activity: IActivity) => {
    agent.Activities.create(activity).then(() => {
      setActivities([...activities, activity]);
      setSelectedActivity(activity);
      setEditMode(false);
    });
  };

  const handleEditActivity = (activity: IActivity) => {
    agent.Activities.update(activity).then(() => {
      setActivities([
        ...activities.filter(a => a.id !== activity.id),
        activity
      ]);
      setSelectedActivity(activity);
      setEditMode(false);
    });
  };

  const handleDeleteActivity = (id: string) => {
    agent.Activities.delete(id);
    setActivities([...activities.filter(a => a.id !== id)]);
  };

  useEffect(() => {
    agent.Activities.list() // if we hover over it, this return a promise, we want to make sure we are accpting Activity promise
      .then(response => {
        let activities: IActivity[] = [];
        response.forEach(activity => {
          activity.date = activity.date.split(".")[0];
          activities.push(activity);
        });
        setActivities(activities);
      });
  }, []);

  return (
    <Fragment>
      <NavBar openCreateForm={handleOpenCreateForm} />
      <Container style={{ marginTop: "7em" }}>
        <ActivityDashBoard
          activities={activities}
          selectActivity={handleSelectActivity}
          selectedActivity={selectedActivity!}
          editMode={editMode}
          setEditMode={setEditMode}
          setSelectedActivity={setSelectedActivity}
          createActivity={handleCreateActivity}
          editActivity={handleEditActivity}
          deleteActivity={handleDeleteActivity}
        />
      </Container>
    </Fragment>
  );
};

export default App;
