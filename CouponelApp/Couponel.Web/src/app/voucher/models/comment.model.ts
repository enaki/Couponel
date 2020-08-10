import {CommentUserModel} from './comment.user.model';

export type CommentModel = {
  userId: string;
  id: string;
  dateAdded: Date;
  content: string;
  user: CommentUserModel;
};
