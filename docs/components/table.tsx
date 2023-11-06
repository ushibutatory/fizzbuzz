import { IResult } from "@/models/IResult";
import React from "react";

const Table = (props: { results: IResult[] }) => {
  const results = Array.from(props.results);

  if (!results || results.length == 0) return "";

  return (
    <table>
      <thead>
        <tr>
          <th>数字 (number)</th>
          <th>発声 (text)</th>
        </tr>
      </thead>
      <tbody>
        {results.map((_) => {
          return (
            <React.Fragment key={_.OriginalValueText}>
              <tr>
                <td>{_.OriginalValueText}</td>
                <td>{_.ConvertedText}</td>
              </tr>
            </React.Fragment>
          );
        })}
      </tbody>
    </table>
  );
};

export default Table;
