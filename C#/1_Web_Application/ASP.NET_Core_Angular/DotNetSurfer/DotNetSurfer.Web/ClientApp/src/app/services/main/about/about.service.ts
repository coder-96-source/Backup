import { Injectable } from '@angular/core';
import { Feature, FeatureType } from '../../../models/feature';
import { GatewayService } from '../../shared/gateway.service';

@Injectable()
export class AboutService {
    constructor(private gateway: GatewayService) {

    }

    getBackendFeatures() {
        return this.gateway.get(`api/features/${FeatureType[FeatureType.Backend]}`);
    }

    getFrontendFeatures() {
        return this.gateway.get(`api/features/${FeatureType[FeatureType.Frontend]}`);
    }
} 
