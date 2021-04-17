import { Category } from "./category";
import { Priority } from "./priority";
import { User } from "./user";

export class Task {
    taskId!: number;
    title!: string;
    description!: string;
    creationDate?: Date;
    endDate?: Date;
    deletedDate?: Date;
    active!: boolean;
    archived!: boolean;
    priorityId?: number;
    priority!: Priority;
    categoryId?: number;
    category!: Category;
    userId?: number;
    user!: User;
}
