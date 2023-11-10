import { IResult } from "@/models/IResult";
import axios, { AxiosResponse } from "axios";

type loadingStatus = (isLoading: boolean) => void;

export default class NabeatsuService {
  private static readonly _url: string = "https://m0arwwe4k8.execute-api.ap-northeast-1.amazonaws.com/prod/nabeatsu";

  private _setIsLoading: loadingStatus;

  public constructor() {
    this._setIsLoading = () => {};
  }

  public setLoadingStatus(setIsLoading: loadingStatus): NabeatsuService {
    this._setIsLoading = setIsLoading;
    return this;
  }

  public async execute(start: number, count: number): Promise<IResult[]> {
    this._setIsLoading(true);

    return await axios
      .post(NabeatsuService._url, {
        start: start.toString(),
        count: count.toString(),
      })
      .then((response: AxiosResponse<IResult[]>) => {
        return response.data;
      })
      .catch((error) => {
        console.log(error);
        throw error;
      })
      .finally(() => {
        this._setIsLoading(false);
      });
  }
}
