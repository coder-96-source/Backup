import { Article } from './article';

export class Topic {
    topicId: number;
    title: string;
    category: string;
    description: string;
    picture: number;
    pictureMimeType: string;
    postDate: Date;
    modifyDate: Date;
    showFlag: boolean;

    articles: Article[];
}