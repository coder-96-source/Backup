import { Injectable } from '@angular/core';
import { Topic } from '../../models/dataModel/topic';
import { JWTGatewayService } from '../jwtgateway.service';

@Injectable()
export class TopicTableService {
    constructor(private jwtGateway: JWTGatewayService) {

    }

    getTopics() {
        return this.jwtGateway.get('api/Admin/Topics');
    }
} 