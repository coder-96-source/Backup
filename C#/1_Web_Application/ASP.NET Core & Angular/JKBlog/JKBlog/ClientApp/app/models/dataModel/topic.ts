import { Article } from './article';

export class Topic {
    topicId: number;
    name: string;
    category: string;
    description: string;
    picture: number;
    pictureMimeType: string;
    postDate: Date;
    modifyDate: Date;
    showFlag: boolean;

    articles: Article[];
}