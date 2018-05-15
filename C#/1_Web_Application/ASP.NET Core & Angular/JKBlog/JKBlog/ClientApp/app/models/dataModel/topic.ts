import { Article } from './article';

export class Topic {
    topicId: number;
    title: string;
    description: string;
    picture: string;
    pictureMimeType: string;
    postDate: Date;
    modifyDate: Date;
    showFlag: boolean;

    articles: Article[];
}