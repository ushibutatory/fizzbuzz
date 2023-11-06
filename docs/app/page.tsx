"use client";

import React from "react";
import styles from "./page.module.css";
import axios, { AxiosResponse } from "axios";
import { IResult } from "@/models/IResult";
import Table from "../components/table";

const Page = () => {
  const [start, setStart] = React.useState(1);
  const [count, setCount] = React.useState(15);
  const [results, setResults] = React.useState<IResult[]>([]);

  const url = "https://m0arwwe4k8.execute-api.ap-northeast-1.amazonaws.com/prod/nabeatsu";

  const execute = () => {
    axios
      .post(url, {
        start: start.toString(),
        count: count.toString(),
      })
      .then((response: AxiosResponse<IResult[]>) => {
        setResults(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <main className={styles.main}>
      <div>
        <h1>NabeAtsu.API</h1>
        <div>
          <ul>
            <li>
              <a href="https://github.com/ushibutatory/fizzbuzz" target="_blank">
                GitHub
              </a>
            </li>
            <li>
              <a href="https://twitter.com/ushibutatory" target="_blank">
                X(Twitter) @ushibutatory
              </a>
            </li>
          </ul>
        </div>
      </div>
      <div>
        API URL: <span>{url}</span>
      </div>
      <div>
        <p>数値を以下ルールで変換します。</p>
        <div>
          <ul>
            <li>3の倍数と3のつく数の時、アホになります。</li>
            <li>5の倍数の時、犬になります。</li>
            <li>両方の条件を満たす時、アホな犬になります。</li>
          </ul>
        </div>
      </div>
      <div>
        <fieldset>
          <legend>やってみよう！</legend>
          <div>
            <div>
              <span>最初の数 (start)</span>
              <div>
                <input type="number" min={1} value={start} onChange={(e) => setStart(Number(e.currentTarget.value))} />
              </div>
            </div>
            <div>
              <span>いくつ数えるか (count)</span>
              <div>
                <input type="number" min={1} value={count} onChange={(e) => setCount(Number(e.currentTarget.value))} />
              </div>
            </div>
            <div>
              <button onClick={execute}>Go!</button>
            </div>
          </div>
        </fieldset>
      </div>
      <div>
        <Table results={results} />
      </div>
    </main>
  );
};

export default Page;
