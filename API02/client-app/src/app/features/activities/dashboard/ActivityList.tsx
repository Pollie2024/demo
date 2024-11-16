import React from 'react';
import { Item,Segment } from 'semantic-ui-react';
import { Activity } from '../../../models/activity';



interface Props {
    activities: Activity[];
}
export default function ActivityList({activities}: Props) {
    return (
        <Segment>
            <Item.Group divided>
                {activities.map((activity: Activity) => (
                    <Item key={activity.id}>
                        <Item.Content>
                            <Item.Header as='a'>{activity.title}</Item.Header>
                            <Item.Meta>{activity.date}</Item.Meta>
                            <Item.Description>
                                <div>{activity.description}</div>
                                <div>{activity.city}, {activity.venue}</div>
                            </Item.Description>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
            <ul>
                {activities.map((activity: Activity) => (
                    <li key={activity.id}>{activity.title}</li>
                ))}
            </ul>
        </Segment>
    );
}