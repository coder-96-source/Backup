import { Injectable } from '@angular/core';
import { Topic } from '../../models/dataModel/topic';
import { JWTGatewayService } from '../jwtgateway.service';

@Injectable()
export class TopicDialogService {

    constructor(private jwtGateway: JWTGatewayService) {

    }

    getTopic(topicId: number) {
        return this.jwtGateway.get(`api/Admin/Topic/${topicId}`);
    }

    createTopic(topic: Topic) {
        return this.jwtGateway.post('api/Admin/Topic/Create', topic);
    }

    updateTopic(topic: Topic) {
        return this.jwtGateway.put(`api/Admin/Topic/Update/${topic.topicId}`, topic);
    }

    deleteTopic(topicId: number) {
        return this.jwtGateway.delete(`api/Admin/Topic/Delete/${topicId}`);
    }
}
