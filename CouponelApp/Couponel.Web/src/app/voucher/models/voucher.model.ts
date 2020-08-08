import { CommentModel } from './comment.model';

export type VoucherModel = {
  id?: string;
  name: string;
  category: string;
  expirationDate: string;
  description: string;
  comments: CommentModel[];
};
