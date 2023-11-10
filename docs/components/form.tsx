import { IResult } from "@/models/IResult";
import React from "react";
import Loading from "./loading";
import styles from "../app/form.module.scss";
import NabeatsuService from "@/services/nabeatsuService";

const Form = () => {
  const [start, setStart] = React.useState<number>(1);
  const [count, setCount] = React.useState<number>(15);
  const [isLoading, setIsLoadaing] = React.useState(false);
  const [results, setResults] = React.useState<IResult[]>([]);

  const onClick = async () => {
    const service = new NabeatsuService().setLoadingStatus((isLoading: boolean) => {
      setIsLoadaing(isLoading);
    });

    try {
      const results = await service.execute(start, count);
      setResults(results);
    } catch (e) {
      console.log(e);
    }
  };

  const noResult = !results || results.length == 0;

  const formatter = new Intl.NumberFormat();

  return (
    <div className="row">
      <div className="col-md-6">
        <fieldset>
          <legend>やってみよう！</legend>
          <div>
            <table>
              <tbody>
                <tr>
                  <th>
                    <span className="form-label">最初の数 (start)</span>
                  </th>
                  <td>
                    <input
                      type="number"
                      className="form-control"
                      min={1}
                      value={start}
                      onChange={(e) => setStart(Number(e.currentTarget.value))}
                    />
                  </td>
                </tr>
                <tr>
                  <th>
                    <span className="form-label">いくつ数えるか (count)</span>
                  </th>
                  <td>
                    <input
                      type="number"
                      className="form-control col-auto"
                      min={1}
                      value={count}
                      onChange={(e) => setCount(Number(e.currentTarget.value))}
                    />
                  </td>
                </tr>
              </tbody>
            </table>
            <div className={styles.run}>
              <button className="btn btn-primary" onClick={onClick}>
                Go!
              </button>
              <Loading visible={isLoading} />
            </div>
          </div>
        </fieldset>
      </div>
      <div className="col-md-6">
        {noResult ? (
          <></>
        ) : (
          <table className="table table-hover">
            <thead>
              <tr>
                <th>数字 (number)</th>
                <th>発声 (text)</th>
              </tr>
            </thead>
            <tbody>
              {results.map((_) => {
                return (
                  <tr key={_.OriginalValueText}>
                    <td>{formatter.format(BigInt(_.OriginalValueText))}</td>
                    <td>{_.ConvertedText}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        )}
      </div>
    </div>
  );
};

export default Form;
